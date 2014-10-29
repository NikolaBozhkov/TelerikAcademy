package homework.android.popups;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;

public class ImageAdapter extends ArrayAdapter<Integer> {
    private Context context;
    private int resourseId;
    private Integer[] imagesIds;

    public ImageAdapter(Context context, int resource, Integer[] objects) {
        super(context, resource, objects);
        this.context = context;
        this.resourseId = resource;
        this.imagesIds = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = ((Activity)this.context).getLayoutInflater();
        View row = inflater.inflate(this.resourseId, parent, false);

        ImageView image = (ImageView) row.findViewById(R.id.imageView);
        image.setImageResource(this.imagesIds[position]);

        return row;
    }
}
