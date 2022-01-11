import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiproductService {

  constructor(private http : HttpClient) { }
  getProduct(){
    // return this.http.get<any>("https://fakestoreapi.com/products")
    return this.http.get<any>("http://localhost:3000/productdata")
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}

