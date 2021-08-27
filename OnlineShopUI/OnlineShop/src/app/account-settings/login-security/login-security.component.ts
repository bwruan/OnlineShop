import { Component, OnInit } from '@angular/core';
import { UpdateAccountRequest } from 'src/app/model/requests/update-account-request';
import { UserAccount } from 'src/app/model/user-account';
import { UserAccountService } from 'src/app/service/user-account-service';

@Component({
  selector: 'app-login-security',
  templateUrl: './login-security.component.html',
  styleUrls: ['./login-security.component.css']
})
export class LoginSecurityComponent implements OnInit {
  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };
  
  updateObj: UserAccount = new UserAccount();
  
  constructor(private userAccountService: UserAccountService) { }

  ngOnInit(): void {
    this.userAccountService.getAccountByEmail()
    .subscribe(res => {
      let nameArray = res.name.split(" ");

      this.updateObj.accountId = Number(localStorage.getItem("accountId"));
      this.updateObj.firstName = nameArray[0];
      this.updateObj.lastName = nameArray[1];
      this.updateObj.email = res.email;
      this.updateObj.password = res.password;
    }, err => {
      this.showMessage = "Unable to get account.";
    });
  }

  updateAccount(){
    this.userAccountService.updateAccount(new UpdateAccountRequest(this.updateObj.accountId, this.updateObj.firstName + " " + this.updateObj.lastName, this.updateObj.email, this.updateObj.password))
    .subscribe(res => {
      location.reload();
    }, err => {
      this.showMessage = err.error;
    })
  }
}
