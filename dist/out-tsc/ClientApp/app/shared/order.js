import * as _ from "lodash";
export class Order {
    constructor() {
        this.orderId = 0;
        this.orderDate = new Date();
        this.orderNumber = "initial";
        this.items = new Array();
    }
    ;
    get subtotal() {
        return _.sum(_.map(this.items, i => i.unitPrice * i.quantity));
    }
    ;
}
export class OrderItem {
    constructor() {
        this.id = 0;
        this.quantity = 0;
        this.unitPrice = 0;
        this.productId = 0;
        this.productCategory = "initial";
        this.productSize = "initial";
        this.productTitle = "initial";
        this.productArtist = "initial";
        this.productArtId = "initial";
    }
}
//# sourceMappingURL=order.js.map