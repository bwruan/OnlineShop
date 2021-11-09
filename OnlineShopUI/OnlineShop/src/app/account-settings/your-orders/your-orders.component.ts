import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/model/order';
import { OrderService } from 'src/app/service/order-service';

@Component({
  selector: 'app-your-orders',
  templateUrl: './your-orders.component.html',
  styleUrls: ['./your-orders.component.css']
})
export class YourOrdersComponent implements OnInit {
  orderList: Order[];
  hasNoOrders: boolean;

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

}
