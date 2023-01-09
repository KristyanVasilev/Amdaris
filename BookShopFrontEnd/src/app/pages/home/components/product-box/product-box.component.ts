import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-product-box',
  templateUrl: './product-box.component.html',
  styleUrls: ['./product-box.component.css']
})
export class ProductBoxComponent {
  @Input() fullWidthMode = false;
  @Output() addToCart = new EventEmitter();
  
  product: any | undefined ={
    id: 1,
    title: 'Need for speed',
    price: 150,
    category: 'game',
    description: 'descriptipn',
    image: 'https://via.placeholder.com/150'
  }

  onAddToCart(): void {
    this.addToCart.emit(this.product);
  }
}
