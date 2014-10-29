package startingwithandroid.gridviewtask;

import java.util.ArrayList;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;

public class MainActivity extends Activity {
	private GridView gridView;
	private ArrayList<String> gridItems = new ArrayList<String>();
	private CustomGridViewAdapter adapter;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		gridItems.add("1");
		gridItems.add("2");
		gridItems.add("3");
		gridItems.add("4");
		gridItems.add("5");
		gridItems.add("6");
		gridItems.add("7");
		gridItems.add("8");
		gridItems.add("9");
		gridItems.add("10");
		gridItems.add("11");
		gridItems.add("12");
		gridItems.add("13");
		gridItems.add("14");
		gridItems.add("15");
		gridItems.add("16");
		gridItems.add("17");
		gridItems.add("18");
		
		gridView = (GridView) this.findViewById(R.id.gridView);
		adapter = new CustomGridViewAdapter(MainActivity.this, R.layout.single_item, gridItems);
		gridView.setAdapter(adapter);
		
		gridView.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				Toast.makeText(getApplicationContext(), gridItems.get(position), Toast.LENGTH_SHORT).show();
			}
		});
	}
}
