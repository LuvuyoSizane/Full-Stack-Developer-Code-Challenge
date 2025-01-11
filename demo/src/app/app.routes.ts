import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { LandingComponent } from './landing/landing.component';

export const routes: Routes = [
    {
        path:'',
        component:LandingComponent
    },
    {
        path:'Login',
       component:LoginComponent
    },
    {
        path:"Register",
        component:RegistrationComponent
    },
    {
        path:"Home",
        component:HomeComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
