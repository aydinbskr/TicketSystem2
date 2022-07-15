import { Injectable } from '@angular/core';
import { Cart } from '../models/cart';
import { CartItem } from '../models/cartItem';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  addToCart(movie:Movie){
    let item=Cart.find(c=>c.movie.movieId===movie.movieId);
    if(item){
      item.quantity+=1;
    }else{
        let cartItem=new CartItem();
        cartItem.movie=movie;
        cartItem.quantity=1;
        Cart.push(cartItem);
    }
  }
  removeFromCart(movie:Movie){
    let item:CartItem=Cart.find(c=>c.movie.movieId===movie.movieId);
    Cart.splice(Cart.indexOf(item),1);
  }
  list():CartItem[]{
    return Cart;
  }
}
