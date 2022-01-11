import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup } from '@angular/forms';
import { bookdetail } from './bookdetail.model';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-admindashboard',
  templateUrl: './admindashboard.component.html',
  styleUrls: ['./admindashboard.component.css']
})
export class AdmindashboardComponent implements OnInit {
public FormValue! : FormGroup;
bookmodelobject: bookdetail = new bookdetail();
bookdata ! : any;
showadd! : boolean;
showupdate! :boolean;
  constructor(private formbuilder: FormBuilder,private api:ApiService) { }

  ngOnInit(): void {
    this.FormValue = this.formbuilder.group({
id: [''],
bookname: [''],
bookcatagory: [''],
bookprice: [''],

bookauthor: [''],
bookimage:['']

     } )
     this.getAllbooks();
  }
  clickAddBook(){this.FormValue.reset();
    this.showadd = true;
    this.showupdate =false
  };
postbookdetails(){
this.bookmodelobject.id = this.FormValue.value.id;
this.bookmodelobject.bookname = this.FormValue.value.bookname;
this.bookmodelobject.bookauthor = this.FormValue.value.bookauthor;
this.bookmodelobject.bookcatagory = this.FormValue.value.bookcatagory;
this.bookmodelobject.bookprice = this.FormValue .value.bookprice;


this.api.postbookdetail(this.bookmodelobject).
subscribe(res=>{console.log(res);alert("BOOK Added successfully")
let ref = document.getElementById('cancel')
ref?.click();
this.FormValue.reset();
this.getAllbooks();},
err=>{alert("Something Went Wrong")})
}
getAllbooks(){

  this.api.getbookdetail().subscribe(res=>{this.bookdata = res;})
}
deleteBooks(row:any){
  this.api.deletebookdetail(row.id).subscribe(res=>{alert("Book Deleted"),this.getAllbooks()})

}
onEdit(row:any){
  this.showadd = false;
    this.showupdate = true;

this.FormValue.controls['id'].setValue(row.id),
this.FormValue.controls['bookname'].setValue(row.bookname),

this.FormValue.controls['bookcatagory'].setValue(row.bookcatagory),

this.FormValue.controls['bookprice'].setValue(row.bookprice),

this.FormValue.controls['bookauthor'].setValue(row.bookauthor),
this.FormValue.controls['boooimage'].setValue(row.bookimage)





}
updatebookdetails(){
  this.bookmodelobject.id = this.FormValue.value.id;
  this.bookmodelobject.bookname = this.FormValue.value.bookname;
  this.bookmodelobject.bookauthor = this.FormValue.value.bookauthor;
  this.bookmodelobject.bookcatagory = this.FormValue.value.bookcatagory;
  this.bookmodelobject.bookprice = this.FormValue.value.bookprice;
// this.api.updatebookdetail(this.bookmodelobject,this.bookmodelobject.id)
this.api.updatebookdetail(this.bookmodelobject,this.bookmodelobject.id).subscribe(res=>{alert("Book UPDATED")
let ref = document.getElementById('cancel')
ref?.click();
this.FormValue.reset();
this.getAllbooks();
})
}

}


