package startingwithadroid.activitiestask;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class TextPresenterActivity extends Activity {
    private TextView view;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		this.setContentView(R.layout.activity_text_presenter);
		view = (TextView)this.findViewById(R.id.textPresenter);
		
		Intent dataFromHomeActivity = this.getIntent();
		String textToPresent = dataFromHomeActivity.getStringExtra("input");
		view.setText(textToPresent);
	}	
}
