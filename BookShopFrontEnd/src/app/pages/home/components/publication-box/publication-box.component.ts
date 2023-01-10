import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-publication-box',
  templateUrl: './publication-box.component.html',
  styleUrls: ['./publication-box.component.css']
})
export class PublicationBoxComponent {
  @Input() fullWidthMode = false;
  @Input() product: any | undefined; 
  @Output() addToCart = new EventEmitter();

  onAddToCart(): void {
    this.addToCart.emit(this.product);
  }
}
