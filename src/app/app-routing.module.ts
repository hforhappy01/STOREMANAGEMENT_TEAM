import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component'
import { CartComponent } from './componant/cart/cart.component';
import { ProductComponent } from './componant/product/product.component';
import { HeaderComponent } from './componant/header/header.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { SignupformComponent } from './signupform/signupform.component';


export const routes: Routes = [

  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'admindashboard',component:AdmindashboardComponent},
  {path:'product',component:ProductComponent},
  {path:'cart',component:CartComponent},
  {path:'header',component:HeaderComponent},
 {path:'home',component:HomeComponent},
 {path:'footer', component:FooterComponent},
 {path:'signupform', component:SignupformComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
