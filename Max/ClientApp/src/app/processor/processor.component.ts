import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-processor',
  templateUrl: './processor.component.html'
})

export class ProcessorComponent {
  public processors: Processor[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Processor[]>(baseUrl + 'api/processor').subscribe(result => {
      this.processors = result;
      console.log(this.processors);
    }, error => console.error(error));
  }
}

interface Processor {

  frequency: number;
  description: string;
  name: string;

}

interface Manufacturer {
  id: number;
  description: string;
  name: string;
}
