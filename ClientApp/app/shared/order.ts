import * as _ from "lodash";


export class Order {
    orderId: number =0 ;
    orderDate: Date = new Date();;
    orderNumber: string = "initial";
    items: Array<OrderItem> = new Array<OrderItem>();

    get subtotal(): number {
        return _.sum(_.map(this.items, i => i.unitPrice * i.quantity));
    };
}

export class OrderItem {
    id: number = 0;
    quantity: number = 0;
    unitPrice: number = 0;
    productId: number = 0;
    productCategory: string = "initial";
    productSize: string = "initial";
    productTitle: string = "initial";
    productArtist: string = "initial";
    productArtId: string = "initial";
}