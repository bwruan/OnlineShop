import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/model/item';
import { ItemService } from 'src/app/service/item-service';

@Component({
  selector: 'app-shop-interface',
  templateUrl: './shop-interface.component.html',
  styleUrls: ['./shop-interface.component.css']
})
export class ShopInterfaceComponent implements OnInit {
  showMessage: any;
  errorMsgStyle: any = {
    color: "red",
    fontStyle: "italic",
    fontSize: "10"
  };
  
  items: Item[];

  constructor(private route: ActivatedRoute, private itemService: ItemService) { }

  ngOnInit(): void {
    let itemTypeId = parseInt(this.route.snapshot.paramMap.get('itemTypeId'));

    if(itemTypeId == 5){
      this.itemService.getAllItems()
      .subscribe(res => {
        this.items = res;
      }, err => {
        this.showMessage = err.error;
      });
    }
    else{
      this.itemService.getItemsByItemType(itemTypeId)
      .subscribe(res => {
        this.items = res;
      }, err => {
        this.showMessage = err.error;
      });
    }
  }

  selectItem(itemId): void{
    
  }
}
