import { Component, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Cart } from 'src/app/model/cart';
import { Item } from 'src/app/model/item';
import { AddToCartRequest } from 'src/app/model/requests/add-to-cart-request';
import { CartService } from 'src/app/service/cart-service';
import { ItemService } from 'src/app/service/item-service';

@Component({
  selector: 'app-shop-interface',
  templateUrl: './shop-interface.component.html',
  styleUrls: ['./shop-interface.component.css']
})
export class ShopInterfaceComponent implements OnInit {
  @ViewChild("addToCartForm") addToCartForm;

  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };
  itemModalState: boolean;
  imageSrc: any;
  
  itemObj: Item = new Item();
  items: Item[];
  cartObj: Cart = new Cart();

  constructor(private route: ActivatedRoute, private itemService: ItemService, private cartService: CartService, private router: Router, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    let itemTypeId = parseInt(this.route.snapshot.paramMap.get('itemTypeId'));

    if(itemTypeId == 5){
      this.itemService.getAllItems()
      .subscribe(res => {
        this.items = res;
        for(let i = 0; i < this.items.length; i++){
          var url = 'data:image/jpg;base64,' + res[i].picture;
          this.items[i].picture = this.sanitizer.bypassSecurityTrustUrl(url);
        }
      }, err => {
        this.showMessage = err.error;
      });
    }
    else{
      this.itemService.getItemsByItemType(itemTypeId)
      .subscribe(res => {
        this.items = res;
        for(let i = 0; i < this.items.length; i++){
          var url = 'data:image/jpg;base64,' + res[i].picture;
          this.items[i].picture = this.sanitizer.bypassSecurityTrustUrl(url);
        }
      }, err => {
        this.showMessage = err.error;
      });
    }
  }

  openItemModal(itemId): void{
    this.itemModalState = true;

    this.itemService.getItemByItemId(itemId)
    .subscribe(res => {
      this.itemObj.itemId = res.itemId;
      this.itemObj.itemTypeId = res.itemTypeId;
      this.itemObj.name = res.name;
      this.itemObj.picture = res.picture;
      this.itemObj.price = res.price;

      var url = 'data:image/jpg;base64,' + res.picture;
      this.imageSrc = this.sanitizer.bypassSecurityTrustUrl(url);

    }, err => {
      this.showMessage = err.error;
    });
  }

  closeItemModal(): void{
    this.itemModalState = false;
    this.showMessage = undefined;
    this.addToCartForm.reset();
  }

  addToCart(itemId){
    this.cartObj.accountId = Number(localStorage.getItem("accountId"));

    this.cartService.addToCart(new AddToCartRequest(itemId, this.cartObj.amount, this.cartObj.accountId))
    .subscribe(res => {
      this.showMessage = "Added to cart.";
      this.closeItemModal();
    }, err => {
      this.showMessage = "Please log in to make purchase.";
    });
  }
}
