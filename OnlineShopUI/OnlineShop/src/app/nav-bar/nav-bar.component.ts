import { Component, OnInit, ViewChild } from '@angular/core';

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

  constructor() { }

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
}
