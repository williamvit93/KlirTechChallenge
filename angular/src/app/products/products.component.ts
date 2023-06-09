import { Component, OnInit } from '@angular/core';
import { createMatrix } from '../helpers/matrixHelper';
import { Product } from '../models/Product';
import { ProductsService } from '../services/products.service';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor(
    private productsService: ProductsService,
    private shoppingCartService: ShoppingCartService
  ) {}

  private _productsRows: Product[][] = [];

  get productsRows(): Product[][] {
    return this._productsRows;
  }
  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productsService.getProducts().subscribe({
      next: (products) => {
        this._productsRows = createMatrix(3, products);
      },
      error: (error) => console.log(error),
    });
  }

  public addProductToCart(product: Product) {
    this.shoppingCartService.addCartProduct(product);
  }
}
