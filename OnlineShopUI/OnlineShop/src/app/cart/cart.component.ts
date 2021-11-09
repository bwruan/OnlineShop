import { Component, OnInit } from '@angular/core';
import { Address } from '../model/address';
import { Cart } from '../model/cart';
import { Payment } from '../model/payment';
import { PurchaseOrderRequest } from '../model/requests/purchase-order-request';
import { AddressService } from '../service/address-service';
import { CartService } from '../service/cart-service';
import { ItemService } from '../service/item-service';
import { OrderService } from '../service/order-service';
import PaymentService from '../service/payment-service';
import { UserAccountService } from '../service/user-account-service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  isNotEmpty: boolean;
  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };

  cartItems: Cart[];
  paymentList: Payment[];
  addressList: Address[];
  paymentObj: Payment = new Payment();
  totalCost: any;

  constructor(private cartService: CartService, private itemService: ItemService, private paymentService: PaymentService, private userAccountService: UserAccountService, 
    private orderService: OrderService, private addressService: AddressService) { }

  ngOnInit(): void {
    this.cartService.getItemsInCartByAccountId()
    .subscribe(res => {
      this.cartItems = res;

      if(this.cartItems.length != 0){
        this.isNotEmpty = true;
      }
      else{
        this.isNotEmpty = false;
      }

      this.cartService.calculateTotal()
      .subscribe(res => {
        this.totalCost = res;
        this.addressService.getAddressesByAccountId()
        .subscribe(res => {
          this.addressList = res;
        }, err => {
          this.showMessage = err.error;
        })
      }, err => {
        this.showMessage = err.error;
      })
      // this.paymentService.getPaymentsByAccountId()
      // .subscribe(res => {
      //   this.paymentList = res;

      //   this.userAccountService.getAccountById()
      //   .subscribe(res => {
      //     this.paymentObj.accountId = res.accountId;
      //   },err => {
      //     this.showMessage = err.error; 
      //   });
      // }, err => {
      //   this.showMessage = "Unable to grab payments.";
      // });
    }, err => {
      console.log(err.error);
    });
  }

  purchaseOrder(){
    let accountId = Number(localStorage.getItem("accountId"));

    this.orderService.purchaseOrder(new PurchaseOrderRequest(accountId))
    .subscribe(res => {
      this.cartService.purchaseRemove()
      .subscribe(res => {
        location.reload();
      }, err => {
        this.showMessage = err.error;
      });
    }, err => {
      this.showMessage = err.error;
    })
  }
}
