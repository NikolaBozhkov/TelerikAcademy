package homework.android.fragments;

import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

public class ProductsList extends Fragment {
    private ViewGroup fragmentView;
    private Product[] products;

    public ProductsList() {
        products = new Product[] {
                new Product("Beer", "Beverage", "1", "5.00$", "5"),
                new Product("Ham", "Food(Meat)", "2", "15.00$", "3"),
                new Product("Mouse", "Technology", "3", "30.00$", "2"),
                new Product("Android App", "Fun", "4", "0.99$", "1"),
                new Product("End product", "The End", "5", "1000.00$", "10000")
        };
    }

    @Override
    public View onCreateView(LayoutInflater inflater, final ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.products_list, container, false);
        this.fragmentView = container;

        ListView productsList = (ListView) view.findViewById(R.id.productsList);
        ProductsAdapter adapter = new ProductsAdapter(view.getContext(), R.layout.product, this.products);
        productsList.setAdapter(adapter);

        productsList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Fragment productInfo = new ProductInfo();
                FragmentManager fm = getFragmentManager();
                FragmentTransaction transaction = fm.beginTransaction();
                transaction.replace(R.id.productsFragment, productInfo);
                transaction.commit();

//                TextView name = (TextView) fragmentView.findViewById(R.id.infoName);
//                TextView category = (TextView) fragmentView.findViewById(R.id.infoCategory);
//                TextView infoId = (TextView) fragmentView.findViewById(R.id.infoId);
//                TextView price = (TextView) fragmentView.findViewById(R.id.infoPrice);
//                TextView quantity = (TextView) fragmentView.findViewById(R.id.infoQuantity);
//
//                Product product = products[position];
//                name.setText("Name: " + product.getName());
//                category.setText("Category: " + product.getCategory());
//                infoId.setText("Name: " + product.getId());
//                price.setText("Name: " + product.getPrice());
//                quantity.setText("Name: " + product.getQuantity());
            }
        });

        return view;
    }
}
