import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }
  postbookdetail(data :any)
  {

    return this.http.post<any>("http://localhost:3000/adminpanel/",data)
  .pipe(map((res:any)=>{return res;}))
  
  }
  getbookdetail()
  {

    return this.http.get<any>("http://localhost:3000/adminpanel/")
  .pipe(map((res:any)=>{return res;}))
  
  }
  updatebookdetail(data :any,id:number)
  {

    return this.http.put<any>("http://localhost:3000/adminpanel/"+id,data)
  .pipe(map((res:any)=>{return res;}))
  
  }
  deletebookdetail(id: number)
  {

    return this.http.delete<any>("http://localhost:3000/adminpanel/" +id)
  .pipe(map((res:any)=>{return res;}))
  
  }
}
