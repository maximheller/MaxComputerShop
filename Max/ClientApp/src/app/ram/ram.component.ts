import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-ram',
  templateUrl: './ram.component.html'
})

export class RamComponent {
  public rams: Ram[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    console.log(localStorage.getItem("token"));

    const httpOptions = {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + localStorage.getItem("token")
      })
    };


    http.get<Ram[]>(baseUrl + 'api/ram', httpOptions)
      .subscribe(result => {
          this.rams = result;
          console.log(this.rams);
      },
        error => console.error(error));


  }
}

interface Ram {
  memoryCapacity: number;
  frequency: number;
  description: string;
  name: string;
  manufacturer: Manufacturer;
  price: number;
}

interface Manufacturer {
  id: number;
  description: string;
  name: string; 
}
