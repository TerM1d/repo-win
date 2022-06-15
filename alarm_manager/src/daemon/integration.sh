#!/bin/bash

touch AlarmPJ.service

echo "[Unit]" > AlarmPJ.service
echo "Description=AlarmPJ service" >> AlarmPJ.service
echo "[Service]" >> AlarmPJ.service
echo "Environment="DISPLAY=:0"" >> AlarmPJ.service
echo "User=$USERNAME" >> AlarmPJ.service
echo "Group=$USERNAME" >> AlarmPJ.service
echo "WorkingDirectory=/home/$USERNAME/alarm-manager-2022/bin" >> AlarmPJ.service
echo "ExecStart=/home/$USERNAME/alarm-manager-2022/bin/alarmd" >> AlarmPJ.service
echo "[Install]" >> AlarmPJ.service
echo "WantedBy=multi-user.target" >> AlarmPJ.service

sudo mv AlarmPJ.service -t /etc/systemd/system/
sudo cp $PWD -r /home/$USERNAME/
echo /home/$USERNAME/alarm-manager-2022/bin/config.conf > /var/tmp/configdir.txt
cd /home/$USERNAME/alarm-manager-2022/

systemctl daemon-reload
systemctl enable AlarmPJ.service
systemctl restart AlarmPJ.service
systemctl status AlarmPJ.service