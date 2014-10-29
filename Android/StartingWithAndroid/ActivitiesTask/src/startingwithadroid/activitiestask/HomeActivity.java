package startingwithadroid.activitiestask;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class HomeActivity extends Activity {
	private Button sendBtn;
	private EditText inputField;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		this.setContentView(R.layout.activity_home);
		
		inputField = (EditText)this.findViewById(R.id.inputField);
		sendBtn = (Button)this.findViewById(R.id.sendInputButt);
		sendBtn.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				Intent intent = new Intent(HomeActivity.this, TextPresenterActivity.class);
				
				String input = inputField.getText().toString();
				intent.putExtra("input", input);
				
				startActivity(intent);
			}
		});
	}	
}
