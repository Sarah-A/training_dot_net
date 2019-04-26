import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Product } from './product';
import { Order, OrderItem } from './order';

// This class will contain all the data that is shared between the different components:
@Injectable()
export class DataService {
	constructor(private http: HttpClient) { }

	private token: string = "";
	private tokenExpiration: Date;

	public products: Product[] = [];
	public order: Order = new Order();

	loadProducts(): Observable<boolean> {
		return this.http.get("/api/products")			// returns an observable that clients can subscribe to to be notified on changes
			.pipe(
			map((data: any[]) => {
				this.products = data;
				return true;
			})
			);
	}

	public get loginRequired(): boolean {
		return (this.token.length == 0 || this.tokenExpiration < new Date());
	}

	login(credentials : any): Observable<boolean> {
		return this.http
			.post("/account/createToken", credentials)
			.pipe(
				map((data: any) => {
					this.token = data.token;
					this.tokenExpiration = data.tokenExpiration;
					return true;
				}));
	}

	


	public addItemToOrder(newProduct: Product) {


		let item: OrderItem = this.order.items.find(i => i.id == newProduct.id);

		if (item) {
			item.quantity++;
		}
		else {
			item = new OrderItem();

			item.id = newProduct.id;
			item.productCategory = newProduct.category;
			item.productTitle = newProduct.title;
			item.productSize = newProduct.size;
			item.productArtId = newProduct.artId;
			item.unitPrice = newProduct.price;
			item.quantity = 1;

			this.order.items.push(item);
		} 

	}
}