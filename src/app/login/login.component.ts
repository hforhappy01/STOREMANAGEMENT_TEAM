import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 public loginform !: FormGroup
  constructor(private formbuilder:FormBuilder, private http:HttpClient,private router:Router) {

   }

  ngOnInit(): void {
    this.loginform  = this.formbuilder.group(
      {
      email :new FormControl('',[Validators.required,Validators.email]) ,
      password :new FormControl('',[Validators.required]) ,
      }
      
      )
      
  }
  get f(){

    return this.loginform.controls;
  }
  login(){
  {
    if (this.loginform.value.email == ['admin@gmail.com']&& this.loginform.value.password == ['123456789']){this.router.navigateByUrl('/admindashboard')}
this.http.get<any>("http://localhost:3000/signupdata")
.subscribe(res=>
  
  {
  const user = res.find((a:any)=>
{
  return a.email === this.loginform.value.email &&  a.password === this.loginform.value.password})
  
if(user){
alert("Login Success") ;
this.loginform.reset();
this.router.navigate(['/product'])

  }
  else{

    alert("User Not Found");
  }
 }) 

  }


}}
