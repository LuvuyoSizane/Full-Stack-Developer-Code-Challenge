// src/app/register/register.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServeService } from '../serve.service';
import { User } from '../classes/user';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-register',
  imports:[ReactiveFormsModule,FormsModule,CommonModule],
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  registerForm : FormGroup;

  constructor(private fb: FormBuilder,private userService: ServeService) { 
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      email: ['', [Validators.required, Validators.email]],
      mobile: ['',Validators.minLength(10),Validators.pattern('^[0-9]*$')],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  

  
  onSubmit(): void {
    if (this.registerForm.invalid) {
      return;
    }

    const user: User = this.registerForm.value;
    this.userService.loginUser (user).subscribe(response => {
      // Handle response, redirect, etc.
    });
  }
}
