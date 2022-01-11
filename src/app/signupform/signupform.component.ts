import { Component, OnInit } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Router } from '@angular/router';
import { Form } from '@angular/forms';


@Component({
  selector: 'app-signupform',
  templateUrl: './signupform.component.html',
  styleUrls: ['./signupform.component.css']
})
export class SignupformComponent implements OnInit {
  public contactForm  !: Form;
  constructor() { }

  ngOnInit(): void {
    

}
submit(form:any){
  var firstName = form.firstName;
  console.log(firstName);

  var lastName = form.lastName;
  console.log(lastName);

  var mobile = form.mobile;
  console.log(mobile);
  var email = form.email;
  console.log(email);
  var password = form.password;
  console.log(password);



  // this.http.post("http://localhost:3000/signupdata",).subscribe(res=>{
  //   alert("Signup Successfull");

  //   this.router.navigate(['/login'])},
  //   err=>{
  //     alert("Something Went Wrong")
  //   })
    
    
        
      }

}



