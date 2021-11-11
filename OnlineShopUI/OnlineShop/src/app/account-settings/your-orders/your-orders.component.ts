import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Order } from 'src/app/model/order';
import { OrderService } from 'src/app/service/order-service';

@Component({
  selector: 'app-your-orders',
  templateUrl: './your-orders.component.html',
  styleUrls: ['./your-orders.component.css']
})
export class YourOrdersComponent implements OnInit {
  orderModalState: boolean;

  orderList: Order[];
  hasNoOrders: boolean;
  orderNumList: Order[];

  constructor(private orderService: OrderService, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.orderService.getOrdersByAccountId()
    .subscribe(res => {
      this.orderList = res;
      for(let i = 0; i < this.orderList.length; i++){
        var url = 'data:image/jpg;base64,' + res[i].orderedItem.picture;
        this.orderList[i].orderedItem.picture = this.sanitizer.bypassSecurityTrustUrl(url);
      }

      if(this.orderList.length != 0){
        this.hasNoOrders = true;
      }
      else{
        this.hasNoOrders = false;
      }
    }, err => {
      console.log(err.error);
    });
  }

  openOrderModal(orderNum){
    this.orderModalState = true;

    this.orderService.getOrdersByOrderNum(orderNum)
    .subscribe(res => {
      this.orderNumList = res;
      for(let i = 0; i < this.orderNumList.length; i++){
        var url = 'data:image/jpg;base64,' + res[i].orderedItem.picture;
        this.orderNumList[i].orderedItem.picture = this.sanitizer.bypassSecurityTrustUrl(url);
      }

    }, err => {
      console.log(err.error);
    })
  }

  closeOrderModal(){
    this.orderModalState = false;
  }
}
