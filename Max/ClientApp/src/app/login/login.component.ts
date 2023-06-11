import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})


export class LoginComponent {

  name: string = "";
  password: string = "";


  constructor(private http: HttpClient, private router: Router) { }

  login() {

    let user = new UserEntity(
      this.name,
      this.password
    );

    console.log(user);
    this.http.post<UserEntity>('api/login', user)
      .pipe(map(data => {
        //console.log("Maxim");
        //console.log(data);
        return data;
      }))
      .subscribe(result => {
        console.log("Maxim2");
        console.log(result.token);
        localStorage.setItem('token', result.token);
      });

    //this.router.navigate([''])
    //  .then(() => {
    //    window.location.reload();
    //  });

  }

}


export class UserEntity {
  token: any;
  constructor(
    public name: string,
    public password: string) {
  }

}
