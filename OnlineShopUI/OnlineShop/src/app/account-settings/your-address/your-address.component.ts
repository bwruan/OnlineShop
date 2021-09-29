import { Component, OnInit, ViewChild } from '@angular/core';
import { Address } from 'src/app/model/address';
import { UserAccount } from 'src/app/model/user-account';
import { AddressService } from 'src/app/service/address-service';
import { UserAccountService } from 'src/app/service/user-account-service';

@Component({
  selector: 'app-your-address',
  templateUrl: './your-address.component.html',
  styleUrls: ['./your-address.component.css']
})
export class YourAddressComponent implements OnInit {
  @ViewChild('addAddressForm') addAddressForm;

  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };
  
  addressList: Address[];
  addressObj: Address = new Address();
  updateObj: Address = new Address();

  addModalState: boolean;
  
  constructor(private addressService: AddressService, private userAccountService: UserAccountService) { }

  ngOnInit(): void {
    this.addressObj.user = new UserAccount();
    
    this.addressService.getAddressesByAccountId()
    .subscribe(res => {
      this.addressList = res;

      this.userAccountService.getAccountById()
      .subscribe(res => {
        this.addressObj.accountId = res.accountId;
        this.addressObj.user.accountId = res.accountId;
        this.addressObj.user.name = res.name; 
      }, err => {
        this.showMessage = err.error; 
      });
    }, err => {
      this.showMessage = "Unable to grab addresses.";
    });
  }

  closeAddModal(){
    
  }
}
