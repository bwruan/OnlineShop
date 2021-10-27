import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Payment } from 'src/app/model/payment';
import PaymentService from 'src/app/service/payment-service';
import { UserAccountService } from 'src/app/service/user-account-service';

@Component({
  selector: 'app-your-payment',
  templateUrl: './your-payment.component.html',
  styleUrls: ['./your-payment.component.css']
})
export class YourPaymentComponent implements OnInit {


  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };

  paymentList: Payment[];
  paymentObj: Payment = new Payment();

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

  constructor(private paymentService: PaymentService, private userAccountService: UserAccountService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.paymentService.getPaymentsByAccountId()
    .subscribe(res => {
      this.paymentList = res;

      this.userAccountService.getAccountById()
      .subscribe(res => {
        this.paymentObj.accountId = res.accountId;
      }, err => {
        this.showMessage = err.error; 
      });
    }, err => {
      this.showMessage = "Unable to grab payments.";
    })
  }

}
