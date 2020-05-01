import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  authChoice = 'login';
  loginForm: FormGroup;
  registerForm: FormGroup;
  loginFormError = '';
  registerFormError = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

  loginWithOauth(){
    this.authService.loginWithOAuth('google');
  }

  loginWithOauthFb(){
    this.authService.loginWithOAuth('facebook');
  }

  onSubmitLoginForm(){

    this.authService.loginWithEmailAndPassword(this.loginForm.value, (error) => {
      if (error){
        this.loginFormError = error;
      } else {
        this.router.navigate(['/movies']);
      }
    });
  }

  onSubmitRegisterForm(){

    this.authService.registerWithEmailAndPassword(this.registerForm.value, (error) => {
      if (error){
        this.registerFormError = error;
      } else {
        this.router.navigate(['/movies']);
      }
    });
  }

}
