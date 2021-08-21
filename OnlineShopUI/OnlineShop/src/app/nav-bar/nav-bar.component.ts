import { Component, OnInit, ViewChild } from '@angular/core';
import { AddAccountRequest } from '../model/requests/add-account-request';
import { LoginRequest } from '../model/requests/login-request';
import { UserAccount } from '../model/user-account';
import { UserAccountService } from '../service/user-account-service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  @ViewChild('signInForm') signInForm;
  @ViewChild('signUpForm') signUpForm;
  
  signInModalState: boolean;
  signUpModalState: boolean;
  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };

  loginObj: UserAccount = new UserAccount();
  signUpObj: UserAccount = new UserAccount();

  constructor(private userAccountService: UserAccountService) { }

  ngOnInit(): void {
  }

  openSignInModal(): void{
    this.closeSignUpModal();
    this.signInModalState = true;
  }

  closeSignInModal(): void{
    this.signInModalState = false;
    this.signInForm.reset();
  }

  openSignUpModal(): void{
    this.closeSignInModal();
    this.signUpModalState = true;
  }

  closeSignUpModal(): void{
    this.signUpModalState = false;
    this.signUpForm.reset();
  }

  isLoggedIn(): boolean{
    return localStorage.length > 0;
  }

  login(){
    this.userAccountService.logIn(new LoginRequest(this.loginObj.email, this.loginObj.password))
    .subscribe(res => {
      this.showMessage = undefined;

      localStorage.setItem("token", res.token);
      localStorage.setItem("email", this.loginObj.email);
      localStorage.setItem("accountId", res.accountId);

      this.closeSignInModal();
    }, err =>{
      this.showMessage = "Unable to log in: " + err.error;      
    });
  }

  logout(){
    this.userAccountService.logOut()
    .subscribe(res => {
      localStorage.clear();
    }, err =>{
      this.showMessage = "Unable to log out: " + err.error;
    });
  }

  signUp(){
    this.userAccountService.addAccount(new AddAccountRequest(this.signUpObj.accountId, this.signUpObj.firstName + " " + this.signUpObj.lastName, this.signUpObj.email, this.signUpObj.password))
    .subscribe(res => {
      location.reload();
    }, err => {
      this.showMessage = err.error;
    })
  }
}
