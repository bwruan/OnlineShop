import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Address } from 'src/app/model/address';
import { AddAddressRequest } from 'src/app/model/requests/add-address-request';
import { UpdateAddressRequest } from 'src/app/model/requests/update-address-request';
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
  @ViewChild('editForm') editForm;

  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };
  
  addressList: Address[];
  addressObj: Address = new Address();
  addAddressObj: Address = new Address();
  updateObj: Address = new Address();

  addModalState: boolean;
  editModalState: boolean;

  stateList: any[] = [{name: "Alabama", abbrev:	"AL"}, {name: "Alaska",	abbrev: "AK"},	{name: "Arizona", abbrev: "AZ"	}, {name: "Arkansas", abbrev:	'AR'}, {name: "California", abbrev:	'CA'}, 
    {name: "Colorado", abbrev: "CO"}, {name: "Connecticut", abbrev:	"CT"}, {name: "Delaware", abbrev:	"DE"}, {name: "Florida", abbrev: "FL"}, {name: "Georgia", abbrev: "GA"}, 
    {name: "Hawaii", abbrev: "HI"}, {name: "Idaho", abbrev: "ID"}, {name: "Illinois", abbrev: "IL"}, {name: "Indiana", abbrev: "IN"}, {name: "Iowa", abbrev: "IA"}, 
    {name: "Kansas", abbrev: "KS"}, {name: "Kentucky", abbrev: "KY"}, {name: "Louisiana", abbrev:	"LA"}, {name: "Maine", abbrev: "ME"}, {name: "Maryland", abbrev: "MD"}, 
    {name: "Massachusetts", abbrev:	"MA"}, {name: "Michigan", abbrev: "MI"}, {name: "Minnesota", abbrev: "MN"}, {name: "Mississippi", abbrev: "MS"}, {name: "Missouri", abbrev: "MO"}, 
    {name: "Montana", abbrev:	"MT"}, {name: "Nebraska", abbrev: "NE"}, {name: "Nevada", abbrev: "NV"}, {name: "New Hampshire", abbrev: "NH"}, {name: "New Jersey", abbrev: "NJ"}, 
    {name: "New Mexico", abbrev: "NM"}, {name: "New York", abbrev:	"NY"}, {name: "North Carolina", abbrev:	"NC"}, {name: "North Dakota", abbrev:	"ND"}, {name: "Ohio", abbrev: "OH"}, 
    {name: "Oklahoma", abbrev: "OK"}, {name: "Oregon", abbrev: "OR"}, {name: "Pennsylvania", abbrev: "PA"}, {name: "Rhode Island", abbrev: "RI"}, {name: "South Carolina", abbrev:	"SC"}, 
    {name: "South Dakota", abbrev: "SD"}, {name: "Tennessee", abbrev: "TN"}, {name: "Texas", abbrev:	"TX"}, {name: "Utah", abbrev: "UT"}, {name: "Vermont", abbrev: "VT"},
    {name: "Virginia", abbrev: "VA"}, {name: "Washington", abbrev: "WA"}, {name: "West Virginia", abbrev: "WV"}, {name: "Wisconsin", abbrev: "WI"}, {name: "Wyoming", abbrev:	"WY"}];
  
  constructor(private addressService: AddressService, private userAccountService: UserAccountService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.addressObj.user = new UserAccount();
    
    this.addressService.getAddressesByAccountId()
    .subscribe(res => {
      this.addressList = res;

      this.userAccountService.getAccountById()
      .subscribe(res => {
        this.addressObj.accountId = res.accountId;
        this.addressObj.user.accountId = res.accountId;
      }, err => {
        this.showMessage = err.error; 
      });
    }, err => {
      this.showMessage = "Unable to grab addresses.";
    });
  }

  openAddModal(){
    this.addModalState = true;
  }

  closeAddModal(){
    this.addModalState = false;
    this.addAddressForm.reset();
  }

  addAddress(){
    this.addAddressObj.accountId = Number(localStorage.getItem("accountId"));

    this.addressService.addAddress(new AddAddressRequest(this.addAddressObj.addressId, this.addAddressObj.customerName, this.addAddressObj.unitStreet, 
      this.addAddressObj.city, this.addAddressObj.state, this.addAddressObj.zipcode, this.addAddressObj.accountId))
      .subscribe(res => {
        location.reload();
      }, err => {
        this.showMessage = err.error;
      });
  }

  openEditModal(addressId){
    this.editModalState = true;

    this.addressService.getAddressByAddressId(addressId)
    .subscribe(res => {
      this.addressObj.addressId = addressId
      this.addressObj.accountId = res.accountId;
      this.addressObj.customerName = res.customerName;
      this.addressObj.addressId = res.addressId;
      this.addressObj.unitStreet = res.unitStreet;
      this.addressObj.city = res.city;
      this.addressObj.state = res.state;
      this.addressObj.zipcode = res.zipcode;
    }, err => {
      this.showMessage = err.error;      
    });
  }

  closeEditModal(){
    this.editModalState = false;
    this.editForm.reset();
  }

  updateAddress(){
    this.addressObj.addressId = parseInt(this.route.snapshot.paramMap.get('id'));

    this.addressService.updateAddress(new UpdateAddressRequest(this.addressObj.addressId, this.addressObj.customerName, this.addressObj.unitStreet, this.addressObj.city, 
      this.addressObj.state, this.addressObj.zipcode))
      .subscribe(res => {
        location.reload();
      }, err => {
        this.showMessage = err.error;
      });
  }

  deleteAddress(addressId){
    this.addressService.deleteAddress(addressId)
    .subscribe(res => {
      location.reload();
    }, err => {
      this.showMessage = err.error;
    });
  }
}
