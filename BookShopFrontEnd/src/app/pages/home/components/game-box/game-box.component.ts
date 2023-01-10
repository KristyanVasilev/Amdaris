import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-game-box',
  templateUrl: './game-box.component.html',
  styleUrls: ['./game-box.component.css']
})
export class GameBoxComponent {
  @Input() fullWidthMode = false;
  @Input() product: any | undefined; 
  @Output() addToCart = new EventEmitter();

  onAddToCart(): void {
    this.addToCart.emit(this.product);
  }
}
