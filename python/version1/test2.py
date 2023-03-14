import cv2
import os
import numpy as np
import face_recognition

# Set up paths
dataset_path = "dataset"
trainer_path = "trainer.yml"

# Load images and encode them
known_face_encodings = []
known_face_names = []

for person_name in os.listdir(dataset_path):
    person_path = os.path.join(dataset_path, person_name)
    if os.path.isdir(person_path):
        for image_name in os.listdir(person_path):
            image_path = os.path.join(person_path, image_name)
            image = face_recognition.load_image_file(image_path)
            face_encoding = face_recognition.face_encodings(image)[0]
            known_face_encodings.append(face_encoding)
            known_face_names.append(person_name)

# Train the face recognition model
face_recognizer = cv2.face.LBPHFaceRecognizer_create()
face_recognizer.train(known_face_encodings, np.array(known_face_names))

# Save the trained model to file
face_recognizer.write(trainer_path)
