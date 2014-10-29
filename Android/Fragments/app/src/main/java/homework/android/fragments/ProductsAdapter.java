package homework.android.fragments;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class ProductsAdapter extends ArrayAdapter<Product> {
    private Context context;
    private int resourceId;
    private Product[] products;

    public ProductsAdapter(Context context, int resource, Product[] products) {
        super(context, resource, products);
        this.context = context;
        this.resourceId = resource;
        this.products = products;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater)this.context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View row = inflater.inflate(this.resourceId, parent, false);

        TextView name = (TextView)row.findViewById(R.id.productName);
        name.setText(this.products[position].getName());

        TextView category = (TextView)row.findViewById(R.id.productCategory);
        category.setText(this.products[position].getCategory());

        return row;
    }
}
