import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServeService } from '../serve.service';
import { User } from '../classes/user';
import { CommonModule } from '@angular/common'; 
@Component({
  selector: 'app-login',
  imports:[ReactiveFormsModule,FormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: ServeService) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const user: User = this.loginForm.value;
      this.authService.loginUser(user).subscribe(response => {
        console.log('User logged in successfully:', response);
        // Handle success (e.g., store token, navigate to dashboard)
      }, error => {
        console.error('Login failed:', error);
        // Handle error
      });
    } else {
      console.log("Form is invalid.");
    }
  }
}
