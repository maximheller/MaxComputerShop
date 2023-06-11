import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-processor-create',
  templateUrl: './processor-create.component.html'
})


export class ProcessorCreateComponent {

  manufacturerId: number = 0;
  frequency: number = 0;
  name: string = "";
  description: string = "";
  price: number = 0;

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  //  //http.get<Phone[]>(baseUrl + 'api/weatherforecast').subscribe(result => {
  //  //  this.forecasts = result;
  //  //}, error => console.error(error));
  //  console.log(baseUrl);
  //}

  constructor(private http: HttpClient, private router: Router) { }

  addProcessor() {


    //let formData: FormData = new FormData();
    //formData.append('pfile', file);

    //const headers = new HttpHeaders({
    //  'Content-Type': 'multipart/form-data',
    //  'Accept': 'application/json'
    //});


    let processor = new ProcessorEntity(
      this.manufacturerId,
      this.frequency,
      this.name,
      this.description,
      this.price
    );

    console.log(processor);
    // this.http.post('api/UploadFiles/UploadFiles/', body, options).pipe(map(data => { return data; }));

    this.http.post('api/processor', processor)
      .pipe(map(data => { return data; }))
      .subscribe(result => {
        console.log(result);
      });


    this.router.navigate(['/processor'])
      .then(() => {
        window.location.reload();
      });

  }

}


export class ProcessorEntity {

  constructor(public manufacturerId: number,
    public frequency: number,
    public name: string,
    public description: string,
    public price: number) {
  }

}
