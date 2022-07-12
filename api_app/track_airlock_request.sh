#!/bin/bash
fqdn=https://airlockdemo.westeuropes.cloudapp.azure.com
token=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjJaUXBKM1VwYmpBWVhZR2FYRUpsOGxWMFRPSSJ9.eyJhdWQiOiJjMDk5NmJhYy1lMTMwLTQxMzQtODhhMy03Yzc4YjMxODRmZDciLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vZTUyN2VhNWMtNjI1OC00Y2QyLWEyN2YtOGJkMjM3ZWM0YzI2L3YyLjAiLCJpYXQiOjE2NTc1NzMyMzQsIm5iZiI6MTY1NzU3MzIzNCwiZXhwIjoxNjU3NTc4MjM5LCJhaW8iOiJBWFFBaS84VEFBQUFKOUVJeFQrTXhIVmoyVWtpR2lSeElLTzQycG5lU3JLcGoxSXdWWU5xZndqeG1ER2tUTmF5ZkxyQUIyYkxRV2ZOdVJpVys1Vk4rbVB2bGxpdnh2dkZrcHMvSmltc2JvdjZTOHVHcUFPb0EzU3hhQUJHTTRiK1BZYWpsNTZrVzdSTm81SzNoKzZxQWRSMmlVaThvckVKS1E9PSIsImF6cCI6ImMwNWYwZDFhLWI2MTQtNGI3ZC1iYjMzLTlhYTAxYTU4YTQ3OCIsImF6cGFjciI6IjAiLCJpZHAiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwibmFtZSI6IkxpemEgU2hha3VyeSIsIm9pZCI6IjcwMDlhOTJmLWY1OGQtNGQ1OS05YTdjLWZiZDZhMDA4NjhhOCIsInByZWZlcnJlZF91c2VybmFtZSI6Imxpc2hha3VyQG1pY3Jvc29mdC5jb20iLCJyaCI6IjAuQVJFQVhPb241VmhpMGt5aWY0dlNOLXhNSnF4cm1jQXc0VFJCaUtOOGVMTVlUOWNSQU53LiIsInJvbGVzIjpbIldvcmtzcGFjZVJlc2VhcmNoZXIiXSwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiZFpIU1lmc05XRXpnOWwtRjI2UUE4WFFZZ0QxZWJHbXgwSmJWTnlNbE5YayIsInRpZCI6ImU1MjdlYTVjLTYyNTgtNGNkMi1hMjdmLThiZDIzN2VjNGMyNiIsInV0aSI6InB5LUdnV0tIeFVxUDR5VXV2d01CQUEiLCJ2ZXIiOiIyLjAifQ.gkzijMr1qHGUNoSLWxKFuj3vfTFxHeD-PrNPudDrVLg-TjLX7Ve5x170kzCWupke0EO6g_ChihPyinXte8-VKFqYgWjcTYbxODgl8daZd5PYMmPBjc1Vmr9cjuNOT46HcvNRAT34kK2BYQyE0-peDBj5BbCtLNOKuAMYtSuwZyl7wmsBZwDcenCx49XJ3SkaPvBxPGx-LhaOVopbi7ibrhVn7yws-0S2CvKuATZSZTcFMhrZTIM16WtLragQluYttEOJbUcWlp8v4A5y0bBevs81u8qd9fQX4p2Rm8T7BqZEhGjIVjlxPwaiEMZ3Y6QFclttkvWPLGHvcV80uwr3Og
workspace=f25c7e4a-7d22-41c6-8820-1cae82f30cbf

RED='\e[31m';
GREEN='\e[32m';
YELLOW='\e[33m';
BLUE='\e[34m';
CYAN='\e[36m';
GREY='\e[90m';

declare -A colors
colors[draft]=$CYAN
colors[submitted]=$YELLOW
colors[in_review]=$BLUE
colors[approval_in_progress]=$GREY
colors[approved]=$GREEN
colors[rejection_in_progress]=$GREY
colors[rejected]=$RED
colors[cancelled]=$RED
colors[blocking_in_progress]=$GREY
colors[blocked_by_scan]=$RED

echo "Request ID:"
read -r request

echo
echo 'Current status:'
while true; do
  response=$(curl --silent "$fqdn/api/workspaces/$workspace/requests/$request" \
    -H "Authorization: Bearer $token" \
    -H 'Connection: keep-alive' \
    -H 'Sec-Fetch-Site: same-origin' \
    -H 'accept: application/json' \
    --compressed \
    --insecure
  )

  status=$(echo $response | tr { '\n' | tr , '\n' | tr } '\n' | grep "status"| awk  -F'"' '{print $4}')

  if [ -z "$status" ]; then
    echo $response
    exit 1
  fi

  # loading icon
  for X in '-' '⣾' '⣽' '⣻' '⢿' '⡿' '⣟' '⣯' '⣷' '⠁' '⠂' '⠄' '⡀' '⢀' '⠠' '⠐' '⠈'; do
   echo -en "\\r\b$X ${colors[$status]}$status";
   sleep 0.1
  done

done

echo
