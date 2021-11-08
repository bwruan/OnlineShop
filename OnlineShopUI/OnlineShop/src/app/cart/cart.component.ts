import { Component, OnInit } from '@angular/core';
import { Cart } from '../model/cart';
import { CartService } from '../service/cart-service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  isNotEmpty: boolean;

  cartItems: Cart[];

  constructor(private cartService: CartService) { }

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
    }, err => {
      console.log(err.error);
    });
  }

}
