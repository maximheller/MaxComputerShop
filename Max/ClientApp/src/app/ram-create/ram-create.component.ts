import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
// import { MatSelectModule } from '@angular/material/select';



@Component({
  selector: 'app-ram-create',
  templateUrl: './ram-create.component.html'
})


export class RamCreateComponent {

  manufacturerId: number = 0;
  memoryCapacity: number = 0;
  frequency: number = 0;
  name: string = "";
  description: string = "";
  price: number = 0;
  public manufacturers: Manufacturer[] = [];
  selectedManufacturer: Manufacturer = this.manufacturers[0];


  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {   

    http.get<Manufacturer[]>(baseUrl + 'api/manufacturer').subscribe(result => {
      this.manufacturers = result;
      this.selectedManufacturer = this.manufacturers[0];
    }, error => console.error(error));

  }

 
  onChangeObj(newObj: Manufacturer) {
    console.log(newObj);
    this.selectedManufacturer = newObj;
  }


  addRam() {


    //let formData: FormData = new FormData();
    //formData.append('pfile', file);

    //const headers = new HttpHeaders({
    //  'Content-Type': 'multipart/form-data',
    //  'Accept': 'application/json'
    //});


    let ram = new RamEntity(
      this.selectedManufacturer.id,
      this.memoryCapacity,
      this.frequency,
      this.name,
      this.description,
      this.price
    );

    console.log(ram);
    // this.http.post('api/UploadFiles/UploadFiles/', body, options).pipe(map(data => { return data; }));


    const httpOptions = {
      headers: new HttpHeaders({
        "Authorization": "Token " + localStorage.getItem("token")
      })
    };

    this.http.post('api/ram', ram, httpOptions)
      .pipe(map(data => { return data; }))
      .subscribe(result => {
        console.log(result);
      });

    this.router.navigate(['/ram'])
      .then(() => {
        window.location.reload();
      });

  }

}


export class RamEntity {

  constructor(public manufacturerId: number,
    public memoryCapacity: number,
    public frequency: number,
    public name: string,
    public description: string,
    public price: number) {
  }

}


export interface Cars {
  value: string;
  viewValue: string;
}

interface Manufacturer {
  id: number;
  description: string;
  name: string;
}


//< mat - form - field appearance = "fill" >
//  <mat-label > Select favourite Car < /mat-label>
//    < mat - select >
//    <mat-option * ngFor="let car of cars"[value] = "car.value" >
//      {{ car.viewValue }}
//</mat-option>
//  < /mat-select>
//  < /mat-form-field>
