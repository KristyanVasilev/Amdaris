import { HttpErrorResponse, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class HttpErrorInterceptor {

  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 400) {
            console.log(error.message, "Bad Request")
          }
          else if (error.status === 404) {
            console.log("Not Found!")
          }
          else if (error.status === 500) {
            console.log("Iternal error!")
            //redirect to smth went wrong
          }
          return throwError(error);
        })
      )
  }
}