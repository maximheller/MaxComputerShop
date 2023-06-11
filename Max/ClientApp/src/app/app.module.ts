import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';



import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RamComponent } from './ram/ram.component';
import { RamCreateComponent } from './ram-create/ram-create.component';
import { ProcessorComponent } from './processor/processor.component';
import { ProcessorCreateComponent } from './processor-create/processor-create.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RamComponent,
    RamCreateComponent,
    ProcessorComponent,
    ProcessorCreateComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'ram', component: RamComponent },
      { path: 'ram-create', component: RamCreateComponent },
      { path: 'processor', component: ProcessorComponent },
      { path: 'processor-create', component: ProcessorCreateComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
