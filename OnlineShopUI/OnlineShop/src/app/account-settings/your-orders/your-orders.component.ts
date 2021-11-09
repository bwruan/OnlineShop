import { Component, OnInit } from '@angular/core';
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

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.getOrdersByAccountId()
    .subscribe(res => {
      this.orderList = res;

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
    }, err => {
      console.log(err.error);
    })
  }

  closeOrderModal(){
    this.orderModalState = false;
  }
}
