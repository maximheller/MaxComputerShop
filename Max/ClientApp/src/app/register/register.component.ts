import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})


export class RegisterComponent {

  name: string = "";
  email: string = "";
  password: string = "";


  constructor(private http: HttpClient, private router: Router) { }

  addUser() {

    let user = new UserEntity(
      this.name,
      this.email,
      this.password
    );

    console.log(user);
    this.http.post('api/register', user)
      .pipe(map(data => { return data; }))
      .subscribe(result => {
        console.log(result);
      });

    this.router.navigate([''])
      .then(() => {
        window.location.reload();
      });

  }

}


export class UserEntity {
  constructor(
    public name: string,
    public email: string,
    public password: string) {
  }

}
