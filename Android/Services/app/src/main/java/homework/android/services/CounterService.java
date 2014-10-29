package homework.android.services;

import android.app.Service;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

import java.util.Timer;
import java.util.TimerTask;

public class CounterService extends Service {
    private final long delay = 1000;
    private Handler handler;
    private Timer timer;
    private long startedOn;

    private Timer getTimer() {
        if (this.timer == null) {
            this.timer = new Timer();
        }

        return this.timer;
    }

    private void updateToast(final String outputTime) {
        this.handler.post(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(getApplicationContext(), "Time passed since start: " + outputTime, Toast.LENGTH_SHORT).show();
            }
        });
    }

    private String getTimePassedFormated() {
        long currentTime = System.currentTimeMillis();
        long timePassed = currentTime - this.startedOn;

        long seconds = (timePassed / 1000) % 60;
        long minutes = (timePassed / (1000 * 60)) % 60;
        long hours = (timePassed / (1000 * 60 * 60)) % 24;
        long milis = timePassed % 1000;

        String outputTime = String.format("%02d:%02d:%02d:%d", hours, minutes, seconds, milis);
        return outputTime;
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        this.handler = new Handler();

        startedOn = System.currentTimeMillis();

        TimerTask task = new TimerTask() {
            @Override
            public void run() {
                String outputTime = getTimePassedFormated();
                updateToast(outputTime);
            }
        };

        this.getTimer().schedule(task, 0, delay);
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        return super.onStartCommand(intent, flags, startId);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        this.getTimer().cancel();
    }
}
