import { Component, Input } from '@angular/core';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { AuthenticationResult, EventMessage, EventType, InteractionStatus } from '@azure/msal-browser';
import { filter, Subject, takeUntil } from 'rxjs';
import { Cart, CartItem } from 'src/app/models/cart';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  private _cart: Cart = { items: [] };
  itemsQuantity = 0;

  @Input()
  get cart(): Cart { return this._cart; }

  set cart(cart: Cart) {
    this._cart = cart;

    this.itemsQuantity = cart.items
      .map((item) => item.quantity)
      .reduce((prev, curent) => prev + curent, 0);
  }

  constructor(private msalService: MsalService,
    private broadCastService: MsalBroadcastService,
    private cartService: CartService) { }

  getTotal(items: CartItem[]): number {
    return this.cartService.getTotal(items);
  }

  onClearCart(): void {
    this.cartService.clearCart();
  }
  isAuthenticated = false;
  activeUser: string | undefined;

  private unsubscribe = new Subject<void>();

  ngOnDestroy(): void {
    this.unsubscribe.next(undefined);
    this.unsubscribe.complete();
  }

  ngOnInit(): void {
    this.broadCastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None),
        takeUntil(this.unsubscribe)

      )
      .subscribe(() => {
        this.setAuthenticationStatus()
      });

    this.broadCastService.msalSubject$
      .pipe(
        filter((message: EventMessage) => message.eventType === EventType.LOGIN_SUCCESS),
        takeUntil(this.unsubscribe)
      )
      .subscribe((message: EventMessage) => {
        const authResult = message.payload as AuthenticationResult;
        this.msalService.instance.setActiveAccount(authResult.account);
        console.log(authResult);
      });
  }


  login(): void {
    this.msalService.instance.loginPopup({
      scopes: ["User.Read"]
    });
  }

  logout(): void {
    this.msalService.instance.logoutRedirect();

  }

  setAuthenticationStatus(): void {
    let activAccount = this.msalService.instance.getActiveAccount();

    if (!activAccount && this.msalService.instance.getAllAccounts().length > 0) {
      activAccount = this.msalService.instance.getAllAccounts()[0];
      this.msalService.instance.setActiveAccount(activAccount);
    }

    this.isAuthenticated = !!activAccount;
    this.activeUser = activAccount?.username; 
    console.log(activAccount)
  }
}
