package startingwithandroid.gridviewtask;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class CustomGridViewAdapter extends ArrayAdapter<String> {
	private Context context;
	private int layoutResourceId;
	private ArrayList<String> data;

	public CustomGridViewAdapter(Context context, int layoutResourceId, ArrayList<String> data) {
		super(context, layoutResourceId, data);
		this.context = context;
		this.layoutResourceId = layoutResourceId;
		this.data = data;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View viewItem = convertView;
		ItemHolder holder;
		
		if (viewItem == null) {
			LayoutInflater inflater = ((Activity)this.context).getLayoutInflater();
			viewItem = inflater.inflate(this.layoutResourceId, parent, false);
			
			holder = new ItemHolder();
			holder.view = (TextView) viewItem.findViewById(R.id.textView);
			
			viewItem.setTag(holder);
		} else {
			holder = (ItemHolder) viewItem.getTag();
		}
		
		String item = data.get(position);
		holder.view.setText(item);
		
		return viewItem;
	}
	
	private static class ItemHolder {
		public TextView view;
	}
}