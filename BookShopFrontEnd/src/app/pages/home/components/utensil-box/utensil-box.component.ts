import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-utensil-box',
  templateUrl: './utensil-box.component.html',
  styleUrls: ['./utensil-box.component.css']
})
export class UtensilBoxComponent {
  @Input() fullWidthMode = false;
  @Input() product: any | undefined; 
  @Output() addToCart = new EventEmitter();

  onAddToCart(): void {
    this.addToCart.emit(this.product);
  }
}
