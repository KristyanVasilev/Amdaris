import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Cart, CartItem } from 'src/app/models/cart';
import { CartService } from 'src/app/services/cart.service';

const STORE_BASE_URL = 'https://localhost:7201/api/Order';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  cart: Cart = { items: [] };
  username!: string;
  email!: string;
  address!: string;
  dataSource: Array<CartItem> = [];
  displayedColumns: Array<string> = [
    'product',
    'name',
    'price',
    'quantity',
    'total',
    'action',
  ];

  constructor(private cartService: CartService,
    private httpClient: HttpClient) { }

  ngOnInit() {
    this.cartService.cart.subscribe((_cart: Cart) => {
      this.cart = _cart;
      this.dataSource = _cart.items;
    });
  }

  onAddQuantity(item: CartItem): void {
    this.cartService.addToCart(item);
  }

  getTotal(items: CartItem[]): number {
    return items
      .map((item) => item.price * item.quantity)
      .reduce((prev, curent) => prev + curent, 0)
  }

  onClearCart(): void {
    this.cartService.clearCart();
  }

  payOnDelivery() {
    const productPostDto = this.cart.items.map(item => {
      return {
        Name: item.name,
        Price: item.price,
        Quantity: item.quantity,
      }
    });

    const OrderPostDto = {
      UserName: this.username,
      Email: this.email,
      Address: this.address,
      Products: productPostDto,
      TotalPrice: this.getTotal(this.cart.items)
    }

    console.log(OrderPostDto)
     this.httpClient.post<any>('https://localhost:7201/api/Order/create', OrderPostDto).subscribe(res => console.log(res));
  }

  onRemoveFromCart(item: CartItem): void {
    this.cartService.removeFromCart(item);
  }

  onRemoveQuantity(item: CartItem): void {
    this.cartService.removeQuantity(item);
  }
}
