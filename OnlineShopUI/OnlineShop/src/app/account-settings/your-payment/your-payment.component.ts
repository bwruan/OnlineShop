import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CardType } from 'src/app/model/card-type';
import { Payment } from 'src/app/model/payment';
import { AddPaymentRequest } from 'src/app/model/requests/add-payment-request';
import { UpdatePaymentRequest } from 'src/app/model/requests/update-payment-request';
import { CardTypeService } from 'src/app/service/card-type-service';
import PaymentService from 'src/app/service/payment-service';
import { UserAccountService } from 'src/app/service/user-account-service';

@Component({
  selector: 'app-your-payment',
  templateUrl: './your-payment.component.html',
  styleUrls: ['./your-payment.component.css']
})
export class YourPaymentComponent implements OnInit {
  @ViewChild('addPaymentForm') addPaymentForm;
  @ViewChild('editForm') editForm;

  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };

  paymentList: Payment[];
  paymentObj: Payment = new Payment();
  addPaymentObj: Payment = new Payment();
  cardTypes: CardType[];

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

  months: any[] = [{name: "January", num: "01"}, {name: "February", num: "02"}, {name: "March", num: "03"}, {name: "April", num: "04"}, {name: "May", num: "05"}, {name: "June", num: "06"}, 
  {name: "July", num: "07"}, {name: "August", num: "08"}, {name: "September", num: "09"}, {name: "October", num: "10"}, {name: "November", num: "11"}, {name: "December", num: "12"}];

  years: any[] = [{full: "2021" , short: "21"}, {full: "2022" , short: "22"}, {full: "2023" , short: "23"}, {full: "2024" , short: "24"}, {full: "2025" , short: "25"}, {full: "2026" , short: "26"}, 
  {full: "2027" , short: "27"}, {full: "2028" , short: "28"}, {full: "2029" , short: "29"}, {full: "2030" , short: "30"}, {full: "2031" , short: "31"}]

  constructor(private paymentService: PaymentService, private userAccountService: UserAccountService, private cardTypeService: CardTypeService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.paymentService.getPaymentsByAccountId()
    .subscribe(res => {
      this.paymentList = res;
    }, err => {
      console.log(err.error);
    });
  }

  openAddModal(){
    this.addModalState = true;

    this.cardTypeService.getCardTypes()
    .subscribe(res => {
      this.cardTypes = res;

      this.addPaymentObj.cardTypeId = this.cardTypes[0].cardTypeId;
    }, err => {
      this.showMessage = err.error;
    });
  }

  closeAddModal(){
    this.addModalState = false;
    this.addPaymentForm.reset();
  }

  addPayment(){
    if(this.addPaymentObj.cardNumber.length != 16){
      this.showMessage = "Card Number must be 16 digits"
      return;
    }

    this.addPaymentObj.accountId = Number(localStorage.getItem("accountId"));
    let addRequest = new AddPaymentRequest(this.addPaymentObj.paymentId, this.addPaymentObj.nameOnCard, this.addPaymentObj.cardNumber, this.addPaymentObj.securityCode, this.addPaymentObj.expMonth + "/" + this.addPaymentObj.expYear, 
      Number(this.addPaymentObj.cardTypeId), this.addPaymentObj.accountId);

    this.paymentService.addPayment(addRequest)
    .subscribe(res => {
      location.reload();
    }, err => {
      this.showMessage = err.error;
    });
  }

  openEditModal(paymentId){
    this.editModalState = true;

    this.paymentService.getPaymentByPaymentId(paymentId)
    .subscribe(res => {
      let dateArr = res.expDate.split("/");

      this.paymentObj.accountId = Number(localStorage.getItem("accountId"));
      this.paymentObj.paymentId = res.paymentId;
      this.paymentObj.cardNumber = res.cardNumber;
      this.paymentObj.cardTypeId = res.cardTypeId;
      this.paymentObj.expMonth = dateArr[0];
      this.paymentObj.expYear = dateArr[1];
      this.paymentObj.nameOnCard = res.nameOnCard;
      this.paymentObj.securityCode = res.securityCode;
    }, err => {
      this.showMessage = "Unable to get card info."
    });

    this.cardTypeService.getCardTypes()
    .subscribe(res => {
      this.cardTypes = res;

      this.addPaymentObj.cardTypeId = this.cardTypes[0].cardTypeId;
    }, err => {
      this.showMessage = err.error;
    });
  }

  closeEditModal(){
    this.editModalState = false;
    this.editForm.reset();
  }

  updatePayment(){
    this.paymentService.updatePayment(new UpdatePaymentRequest(this.paymentObj.paymentId, this.paymentObj.nameOnCard, this.paymentObj.cardNumber, this.paymentObj.securityCode, 
      this.paymentObj.expMonth + "/1/" + this.paymentObj.expYear, this.paymentObj.cardTypeId))
      .subscribe(res => {
        location.reload();
      }, err => {
        console.log(err.error);
      });
  }

  deletePayment(paymentId){
    this.paymentService.deletePayment(paymentId)
    .subscribe(res => {
      location.reload();
    }, err => {
      this.showMessage = err.error;
    });
  }
}
