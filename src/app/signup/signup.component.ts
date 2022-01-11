import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  public signupForm  !: FormGroup;

  constructor(private formbuilder:FormBuilder,private http: HttpClient,private router: Router) { 

    
  }

  ngOnInit(): void {
    this.signupForm = this.formbuilder.group({
      firstname1:[''],
      lastname1:[''],
      mobile1:[''],
      email1:[''],
      password1:['']
       }
       )
    
  }
  
   // this.http.post("http://localhost:8000/signup",this.signupform.value)
  signUp()
  {
    this.http.post("http://localhost:3000/signup",this.signupForm.value).subscribe(res=>{
alert("Signup Successfull");
this.signupForm.reset();
this.router.navigate(['/login'])},
err=>{
  alert("Something Went Wrong")
})


    
  }

}
