package homework.android.fragments;

import android.os.Parcel;
import android.os.Parcelable;

public class Product implements Parcelable {
    private String name;
    private String category;
    private String id;
    private String price;
    private String quantity;

    private Product(Parcel in) {
        String[] data = new String[5];

        in.readStringArray(data);
        this.name = data[0];
        this.category = data[1];
        this.id = data[2];
        this.price = data[3];
        this.quantity = data[4];
    }

    public Product(String name, String category, String id, String price, String quantity) {
        this.setName(name);
        this.setCategory(category);
        this.id = id;
        this.setPrice(price);
        this.setQuantity(quantity);
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getQuantity() {
        return quantity;
    }

    public void setQuantity(String quantity) {
        this.quantity = quantity;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public String getId() {
        return id;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeStringArray(new String[] {this.name, this.category,
                this.id, this.price, this.quantity});
    }

    public static final Parcelable.Creator<Product> CREATOR
            = new Parcelable.Creator<Product>() {
        public Product createFromParcel(Parcel in) {
            return new Product(in);
        }

        public Product[] newArray(int size) {
            return new Product[size];
        }
    };
}
