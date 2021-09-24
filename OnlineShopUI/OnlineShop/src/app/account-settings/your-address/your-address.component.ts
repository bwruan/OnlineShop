import { Component, OnInit } from '@angular/core';
import { Address } from 'src/app/model/address';
import { AddressService } from 'src/app/service/address-service';

@Component({
  selector: 'app-your-address',
  templateUrl: './your-address.component.html',
  styleUrls: ['./your-address.component.css']
})
export class YourAddressComponent implements OnInit {
  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };
  
  addressList: Address[];
  updateObj: Address = new Address();
  
  constructor(private addressService: AddressService) { }

  ngOnInit(): void {
    let accountId = Number(localStorage.getItem("accountId"));
    
    this.addressService.getAddressesByAccountId(accountId)
    .subscribe(res => {
      this.addressList = res;
    }, err => {
      this.showMessage = "Unable to grab addresses.";
    });
  }
}
