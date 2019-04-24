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

	public addItemToOrder(newProduct: Product) {
		
		let item: OrderItem = new OrderItem();

		item.id = newProduct.id;
		item.productTitle = newProduct.title;
		item.productSize = newProduct.size;
		item.unitPrice = newProduct.price;
		item.quantity = 1;

		this.order.items.push(item);

	}
}